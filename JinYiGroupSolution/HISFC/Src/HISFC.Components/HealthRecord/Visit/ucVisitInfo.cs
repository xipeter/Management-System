using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.BizLogic.HealthRecord.Visit;
using Neusoft.HISFC.Components.HealthRecord.CaseFirstPage;
using System.Collections;

namespace Neusoft.HISFC.Components.HealthRecord.Visit
{

    /// <summary>
    /// [功能描述: 待随访患者信息]<br></br>
    /// [创建者:   金鹤]<br></br>
    /// [创建时间: 2009-09-15]<br></br>
    /// <说明>
    ///    
    /// </说明>
    /// </summary>
    public partial class ucVisitInfo : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        /// <summary>
        /// 
        /// </summary>
        public ucVisitInfo()
        {
            InitializeComponent();
        }

        #region 工具栏信息

        /// <summary>
        /// 定义工具栏服务
        /// </summary>
        protected Neusoft.FrameWork.WinForms.Forms.ToolBarService toolBarService = new Neusoft.FrameWork.WinForms.Forms.ToolBarService();

        #region 初始化工具栏
        /// <summary>
        /// 初始化工具栏
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="neuObject"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        protected override Neusoft.FrameWork.WinForms.Forms.ToolBarService OnInit(object sender, object neuObject, object param)
        {
            toolBarService.AddToolButton("作废", "作废", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S删除, true, false, null);
            toolBarService.AddToolButton("随访列表", "随访列表", (int)Neusoft.FrameWork.WinForms.Classes.EnumImageList.S刷新, true, false, null);
            return toolBarService;
        }
        #endregion

        #region 工具栏增加按钮单击事件
        /// <summary>
        /// 工具栏增加按钮单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public override void ToolStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Text)
            {
                case "作废":
                    DeleteRecord();
                    break;
                case "随访列表":
                    RefreshVisitList();
                    break;
                default:
                    break;
            }
        }
        #endregion

        #endregion

        #region 变量

        /// <summary>
        /// 随访业务类

        /// </summary>
        VisitRecord visitRecordManager = new VisitRecord();

        //标志 标识是医生站用还是病案调用
        private Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes frmType = Neusoft.HISFC.Models.HealthRecord.EnumServer.frmTypes.DOC;

        HealthRecord.Search.ucPatientList ucPatient = new HealthRecord.Search.ucPatientList();

        

        #endregion

        #region 事件

        private void ucVisitInfo_Load(object sender, EventArgs e)
        {
            ucPatient.Visible = false;
            this.ucPatient.SelectItem += new HealthRecord.Search.ucPatientList.ListShowdelegate(ucPatient_SelectItem);

            this.Controls.Add(this.ucPatient);

            LoadVisitList();

            SetVisitRecordStyle();
        }

        private void fp_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {

            string txtPatientNO = this.fp_Sheet1.Cells[this.fp_Sheet1.ActiveRowIndex, 0].Value.ToString().Trim().PadLeft(10, '0');

            if (!this.ucPatient.Visible)
            {
                #region 查询
                ArrayList list = null;
                list = ucPatient.Init(txtPatientNO, "2");
                if (list == null)
                {
                    MessageBox.Show("查询失败" + ucPatient.strErr);
                    return;
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("没有查到相关病案信息,是否手工录入病案", "提示");
                }
                else if (list.Count == 1) //只有一条信息
                {
                    ucPatient.Visible = false;
                    Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                    if (obj != null)
                    {
                        ShowCaseMainInfo(obj.PatientInfo.ID);   
                    }
                }
                else //多条信息 
                {
                    this.ucPatient.Location = new Point(Control.MousePosition.X, Control.MousePosition.Y);
                    this.ucPatient.BringToFront();
                    this.ucPatient.Visible = true;
                }
                #endregion
            }
            else
            {
                #region  选择
                Neusoft.HISFC.Models.HealthRecord.Base obj = this.ucPatient.GetCaseInfo();
                if (obj != null)
                {
                    ShowCaseMainInfo(obj.PatientInfo.ID);
                }
                this.ucPatient.Visible = false;
                #endregion
            }

        }

        void ucPatient_SelectItem(Neusoft.HISFC.Models.HealthRecord.Base HealthRecord)
        {
            ShowCaseMainInfo(HealthRecord.PatientInfo.ID);
        }

        private void fp_CellClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            //当前选择的随访患者病历号
            string cardNo = fp_Sheet1.Cells[e.Row, 1].Text.Trim();
          

            if (!string.IsNullOrEmpty(cardNo))
            {
                if (QueryVisitRecordByCardNo(cardNo) == -1)
                {
                    MessageBox.Show("明细信息查询失败");
                }
            }
            

        }

        private void tsmDel_Click(object sender, EventArgs e)
        {
            DeleteRecord();
        }

        #endregion

        #region 方法

        /// <summary>
        /// 加载待随访用户列表
        /// </summary>
        private void LoadVisitList()
        {
            DataSet ds = new DataSet();//待随访患者列表
            if (visitRecordManager.PatQuery(ref ds) > -1)
            {
                this.fp_Sheet1.DataSource = ds.Tables[0].DefaultView;
            }
        }


        /// <summary>
        /// 加载病案信息
        /// </summary>
        /// <param name="patientNo"></param>
        private void ShowCaseMainInfo(string patientNo)
        {
            ucCaseMainInfo ucDetail = new ucCaseMainInfo();

            ucDetail.IsVisitInput = true;//窗体标识为随访录入

            ucDetail.PatientNo = this.fp_Sheet1.Cells[this.fp_Sheet1.ActiveRowIndex, 0].Value.ToString().Trim().PadLeft(10, '0');
            ucDetail.CardNo = this.fp_Sheet1.Cells[this.fp_Sheet1.ActiveRowIndex, 1].Value.ToString().Trim();

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
            Application.DoEvents();

            ucDetail.LoadInfo(patientNo, this.frmType);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            DialogResult result = Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(ucDetail);
        }

        /// <summary>
        /// 获取随访明细信息
        /// </summary>
        /// <param name="cardNo">病历号</param>
        /// <returns>成功返回 0;失败返回 -1</returns>
        private int QueryVisitRecordByCardNo(string cardNo)
        {
            //随访明细列表
            ArrayList list = new ArrayList();
            list = visitRecordManager.QueryByCardNo(cardNo);

            if (list == null)
            {
                return 0;
            }
            fpVisitRecord_Sheet1.Rows.Count = list.Count;
            for (int i = 0; i < list.Count; i++)
            {
                Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord
                    = list[i] as Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord;


                if (visitRecord != null)
                {
                    this.fpVisitRecord_Sheet1.Cells[i, 1].Text = visitRecord.VisitOper.OperTime.ToShortDateString();//随访时间

                    this.fpVisitRecord_Sheet1.Cells[i, 2].Text = visitRecord.LinkWay.LinkMan.Name;//联系人

                    this.fpVisitRecord_Sheet1.Cells[i, 3].Text = visitRecord.VisitType.Name;//随访方式

                    this.fpVisitRecord_Sheet1.Cells[i, 4].Text = visitRecord.VisitResult.Name;//随访结果

                    this.fpVisitRecord_Sheet1.Cells[i, 5].Text = visitRecord.Circs.Name;//一般情况名称

                    this.fpVisitRecord_Sheet1.Cells[i, 6].Text = visitRecord.Symptom.Name;//症状表现


                    this.fpVisitRecord_Sheet1.Cells[i, 7].Text = visitRecord.IsDead ? "是" : "否";//是否死亡

                    this.fpVisitRecord_Sheet1.Cells[i, 8].Text = visitRecord.DeadTime.ToString();//死亡时间

                    this.fpVisitRecord_Sheet1.Cells[i, 9].Text = visitRecord.DeadReason.Name;//死亡原因


                    this.fpVisitRecord_Sheet1.Cells[i, 10].Text = visitRecord.IsRecrudesce ? "是" : "否";//是否复发

                    this.fpVisitRecord_Sheet1.Cells[i, 11].Text = visitRecord.RecrudesceTime.ToString();//复法时间


                    this.fpVisitRecord_Sheet1.Cells[i, 12].Text = visitRecord.IsSequela ? "是" : "否";//是否有后遗症

                    this.fpVisitRecord_Sheet1.Cells[i, 13].Text = visitRecord.Sequela.Name;//后遗症


                    this.fpVisitRecord_Sheet1.Cells[i, 14].Text = visitRecord.IsTransfer ? "是" : "否";//是否转移

                    this.fpVisitRecord_Sheet1.Cells[i, 15].Text = visitRecord.TransferPosition.Name;//后遗症


                    this.fpVisitRecord_Sheet1.Rows[i].Tag = visitRecord;

                }
            }


            return 0;
        }

        /// <summary>
        /// 设置随访明细列表格式
        /// </summary>
        private void SetVisitRecordStyle()
        {
            this.fpVisitRecord_Sheet1.Columns[0].Label = "选择";
            this.fpVisitRecord_Sheet1.Columns[1].Label = "随访时间";
            this.fpVisitRecord_Sheet1.Columns[2].Label = "联系人";
            this.fpVisitRecord_Sheet1.Columns[3].Label = "随访方式";
            this.fpVisitRecord_Sheet1.Columns[4].Label = "随访结果";
            this.fpVisitRecord_Sheet1.Columns[5].Label = "一般情况名称";
            this.fpVisitRecord_Sheet1.Columns[6].Label = "症状表现";
            this.fpVisitRecord_Sheet1.Columns[7].Label = "是否死亡";
            this.fpVisitRecord_Sheet1.Columns[8].Label = "死亡时间";
            this.fpVisitRecord_Sheet1.Columns[9].Label = "死亡原因";
            this.fpVisitRecord_Sheet1.Columns[10].Label = "是否复发";
            this.fpVisitRecord_Sheet1.Columns[11].Label = "复发时间";
            this.fpVisitRecord_Sheet1.Columns[12].Label = "是否有后遗症";
            this.fpVisitRecord_Sheet1.Columns[13].Label = "后遗症";
            this.fpVisitRecord_Sheet1.Columns[14].Label = "是否转移";
            this.fpVisitRecord_Sheet1.Columns[15].Label = "转移部位";

            this.fpVisitRecord_Sheet1.Columns[0].Width = 40;
            this.fpVisitRecord_Sheet1.Columns[1].Width = 60;
            this.fpVisitRecord_Sheet1.Columns[2].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[3].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[4].Width = 60;
            this.fpVisitRecord_Sheet1.Columns[5].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[6].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[7].Width = 60;
            this.fpVisitRecord_Sheet1.Columns[8].Width = 120;
            this.fpVisitRecord_Sheet1.Columns[9].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[10].Width = 60;
            this.fpVisitRecord_Sheet1.Columns[11].Width = 120;
            this.fpVisitRecord_Sheet1.Columns[12].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[13].Width = 80;
            this.fpVisitRecord_Sheet1.Columns[14].Width = 60;
            this.fpVisitRecord_Sheet1.Columns[15].Width = 80;


            this.fpVisitRecord_Sheet1.Columns.Get(0).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(1).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(2).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(3).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(4).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(5).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(6).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(7).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(8).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(9).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(10).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(11).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(12).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(13).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(14).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;
            this.fpVisitRecord_Sheet1.Columns.Get(15).HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;


        }

        /// <summary>
        /// 删除随访记录明细
        /// </summary>
        /// <returns>成功返回 0;失败返回 -1</returns>
        private int DeleteRecord()
        {
            if (MessageBox.Show("是否作废选择的历史随访信息?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {

                visitRecordManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

                for (int i = 0; i < fpVisitRecord_Sheet1.Rows.Count; i++)
                {
                    if (this.fpVisitRecord_Sheet1.Cells[i, 0].Text == true.ToString())
                    {
                        Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord visitRecord
                    = fpVisitRecord_Sheet1.Rows[i].Tag
                    as Neusoft.HISFC.Models.HealthRecord.Visit.VisitRecord;//Tag中的对象
                        if (visitRecord != null)
                        {
                            if (visitRecordManager.DelVisitRecord(visitRecord.ID) == -1)
                            {
                                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                                //t.RollBack();
                                MessageBox.Show("删除联系人发生错误:" + visitRecordManager.Err);
                                return -1;
                            }                       
                        }
                    }
                }

                Neusoft.FrameWork.Management.PublicTrans.Commit();

                #region 重新加载随访明细
                
               
                if (fp_Sheet1.ActiveRowIndex > -1)
                {
                    //当前选择的随访患者病历号
                    string cardNo = fp_Sheet1.Cells[fp_Sheet1.ActiveRowIndex, 1].Text.Trim();


                    if (!string.IsNullOrEmpty(cardNo))
                    {
                        if (QueryVisitRecordByCardNo(cardNo) == -1)
                        {
                            MessageBox.Show("明细信息查询失败");
                        }
                    }
                }

                #endregion

            }

            return 0;
        }

        /// <summary>
        /// 更新随访患者列表
        /// </summary>
        private void RefreshVisitList()
        {
            if (MessageBox.Show("是否重新生成待随访用户列表?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
                == DialogResult.Yes)
            {
                    //等待窗口
                    Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                    Application.DoEvents();

                    if (visitRecordManager.RefreshVisitList() > -1)
                    {
                        LoadVisitList();
                    }
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            }
        }

        #endregion

      

       




    }
}
