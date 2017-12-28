using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using Neusoft.HISFC.Models.RADT;

namespace HeNanProvinceSI.Control
{
    /// <summary>
    /// 省保手工上传明细 wbo 2010-08-03
    /// </summary>
    public partial class frmExportDetailsAndGetResult : Form
    {
        public frmExportDetailsAndGetResult()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 患者基本信息综合实体
        /// </summary>
        Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Models.RADT.PatientInfo();

        /// <summary>
        /// 入出转integrate层
        /// </summary>
        Neusoft.HISFC.BizProcess.Integrate.RADT radtIntegrate = new Neusoft.HISFC.BizProcess.Integrate.RADT();

        /// <summary>
        /// 接口业务层
        /// </summary>
        Neusoft.HISFC.BizLogic.Fee.Interface interfaceMgr = new Neusoft.HISFC.BizLogic.Fee.Interface();

        /// <summary>
        /// 医保业务层
        /// </summary>
        private LocalManager localManager = new LocalManager();

        /// <summary>
        /// 患者费用明细
        /// </summary>
        ArrayList alItemDetail = new ArrayList();

        /// <summary>
        /// 医保对照字典
        /// </summary>
        Hashtable htCompare = new Hashtable();

        /// <summary>
        /// 日期格式
        /// </summary>
        protected const string DATE_TIME_FORMAT = "yyyyMMddHHmmss";

        /// <summary>
        /// 共享目录
        /// </summary>
        private static string FILE_PATH = string.Empty;

        /// <summary>
        /// 扩展属性KEY
        /// </summary>
        public const string EXTEND_PROPERTY_KEY = "HeNanProvinceSI";

        /// <summary>
        /// 患者基本信息
        /// </summary>
        private string patientBaseInfo = "姓名：{0}  床号：{1}  住院号：{2}  医保流水号：{3} 合同单位：{4}  科室：{5}  总金额：{6}";

        private void ucQueryInpatientNo_myEvent()
        {
            this.Clear();
            if (this.ucQueryInpatientNo.InpatientNo == null || this.ucQueryInpatientNo.InpatientNo.Trim() == "")
            {
                if (this.ucQueryInpatientNo.Err == "")
                {
                    ucQueryInpatientNo.Err = "此患者不在院!";
                }
                Neusoft.FrameWork.WinForms.Classes.Function.Msg(this.ucQueryInpatientNo.Err, 211);
                this.ucQueryInpatientNo.Focus();
                return;
            }
            PatientInfo temp = this.localManager.GetSIPersonInfo(this.patientInfo.ID, "0");
            if (temp == null)
            {
                MessageBox.Show("获取中间表患者信息失败！");
                this.ucQueryInpatientNo.Focus();
                return;
            }
            this.patientInfo.SIMainInfo.RegNo = temp.SIMainInfo.RegNo;

            //获取住院号赋值给lbl
            this.patientInfo = this.radtIntegrate.GetPatientInfomation(this.ucQueryInpatientNo.InpatientNo);
            this.lblPatientInfo.Text = string.Format(this.patientBaseInfo, this.patientInfo.Name, this.patientInfo.PVisit.PatientLocation.Bed.ID,
                this.patientInfo.ID.Substring(4), this.patientInfo.SIMainInfo.RegNo, this.patientInfo.Pact.Name, this.patientInfo.PVisit.PatientLocation.Dept.Name,
                this.patientInfo.FT.TotCost.ToString());
        }

        /// <summary>
        /// 创建配置文件
        /// </summary>
        /// <returns></returns>
        public static int CreateSISetting()
        {
            try
            {
                XmlDocument docXml = new XmlDocument();
                XmlElement root = docXml.CreateElement("root");
                docXml.AppendChild(root);

                XmlElement elem1 = docXml.CreateElement("共享目录");
                string gxml = Application.StartupPath + "/HeNanProSI";//共享目录
                if (System.IO.Directory.Exists(gxml) == false)
                {
                    System.IO.Directory.CreateDirectory(gxml);
                }
                elem1.SetAttribute("path", Application.StartupPath + "/HeNanProSI");
                root.AppendChild(elem1);

                docXml.Save(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/" + EXTEND_PROPERTY_KEY + "SiSetting.xml");
            }
            catch (Exception ex)
            {
                MessageBox.Show("写入配置信息出错!" + ex.Message);
                return -1;
            }
            return 1;
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        private void ReadSISetting()
        {
            if (!System.IO.File.Exists(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/" + EXTEND_PROPERTY_KEY + "SiSetting.xml"))
            {
                if (CreateSISetting() == -1)
                {
                    return;
                }
            }
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(Neusoft.FrameWork.WinForms.Classes.Function.SettingPath + "/" + EXTEND_PROPERTY_KEY + "SiSetting.xml");
                XmlNode node = doc.SelectSingleNode("//共享目录");
                FILE_PATH = node.Attributes["path"].Value.ToString();
                if (string.IsNullOrEmpty(FILE_PATH.Trim()))
                {
                    MessageBox.Show("请在配置文件中维护共享目录");
                    return;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("获取配置信息出错!" + e.Message);
                return;
            }
        }

        /// <summary>
        /// 界面清空
        /// </summary>
        private void Clear()
        {
            this.lblPatientInfo.Text = "请输入患者住院号回车！";
            this.neuSpread1.ActiveSheetIndex = 0;
            this.neuSpread1.Sheets[1].Reset();
            this.neuSpread1.Sheets[2].Reset();
        }

        /// <summary>
        /// 显示患者明细
        /// </summary>
        private void ShowFeeDetailsToFP()
        {
            if (this.patientInfo == null)
            {
                return;
            }

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在搜索费用明细，请稍后...");
            Application.DoEvents();

            #region 查询明细
            //查找非药品明细
            ArrayList alItemDetailTemp = this.localManager.QueryFeeItemLists(this.patientInfo.ID, this.patientInfo.Pact.ID, new DateTime(1900, 1, 1), 
                new DateTime(2100, 1, 1), "NO");

            //查找药品明细
            ArrayList alDrugDetailTemp = this.localManager.QueryMedItemLists(this.patientInfo.ID, this.patientInfo.Pact.ID, new DateTime(1900, 1, 1),
                new DateTime(2100, 1, 1), "NO");

            alItemDetail = new ArrayList();
            if (alItemDetailTemp != null && alItemDetailTemp.Count > 0)
            {
                alItemDetail.AddRange(alItemDetailTemp);
            }
            if (alDrugDetailTemp != null && alDrugDetailTemp.Count > 0)
            {
                alItemDetail.AddRange(alDrugDetailTemp);
            }
            if (alItemDetail.Count == 0)
            {
                MessageBox.Show("无费用信息！");
                return;
            }
            #endregion

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示费用明细，请稍后...");

            #region 查询明细对应的医保信息 并显示到界面

            this.neuSpread1.Sheets[1].Reset();
            this.neuSpread1.Sheets[1].RowCount = alItemDetail.Count + 1;
            this.neuSpread1.Sheets[1].Columns.Count = 18;
            int rowCount = 0;
            foreach (Neusoft.HISFC.Models.Fee.Inpatient.FeeItemList item in alItemDetail)
            {
                if (htCompare.Contains(item.Compare.CenterItem.ID))
                {
                    item.Compare = htCompare[item.Compare.CenterItem.ID] as Neusoft.HISFC.Models.SIInterface.Compare;
                }
                else
                {
                    Neusoft.HISFC.Models.SIInterface.Compare com = new Neusoft.HISFC.Models.SIInterface.Compare();
                    this.interfaceMgr.GetCompareSingleItem(this.patientInfo.Pact.ID, item.Item.ID, ref com);
                    if (string.IsNullOrEmpty(item.Compare.CenterItem.ID) == true)
                    {
                        //没有对照项目的处理
                    }
                    else
                    {
                        //已经对照的项目
                        item.Compare = com.Clone();
                        htCompare.Add(item.Compare.CenterItem.ID, item.Compare);
                    }
                }
                this.neuSpread1.Sheets[1].Cells[rowCount++, 0].Value = this.patientInfo.IDCard;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 1].Value = this.patientInfo.SIMainInfo.RegNo;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 2].Value = rowCount.ToString();
                this.neuSpread1.Sheets[1].Cells[rowCount++, 3].Value = item.Compare.CenterItem.ID;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 4].Value = item.Compare.CenterItem.Name;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 5].Value = item.Item.Name;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 6].Value = item.Compare.CenterItem.SysClass;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 7].Value = item.Compare.CenterItem.Specs;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 8].Value = item.Compare.CenterItem.DoseCode;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 9].Value = item.Item.Price.ToString("0.00");
                this.neuSpread1.Sheets[1].Cells[rowCount++, 10].Value = item.Item.Qty.ToString("0.00");
                decimal sum = item.Item.Price * item.Item.Qty;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 11].Value = sum.ToString("0.00");
                this.neuSpread1.Sheets[1].Cells[rowCount++, 12].Value = item.Compare.CenterItem.Rate;
                decimal ownFee = sum * item.Compare.CenterItem.Rate;
                this.neuSpread1.Sheets[1].Cells[rowCount++, 13].Value = ownFee.ToString("0.00");
                this.neuSpread1.Sheets[1].Cells[rowCount++, 14].Value = item.RecipeNO + item.SequenceNO.ToString().PadLeft(2, '0');
                this.neuSpread1.Sheets[1].Cells[rowCount++, 15].Value = item.FeeOper.OperTime.ToString("yyyy.MM.dd");
                this.neuSpread1.Sheets[1].Cells[rowCount++, 16].Value = "";
                this.neuSpread1.Sheets[1].Cells[rowCount++, 17].Value = item.FeeOper.OperTime.ToString("yyyyMMdd");

                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm(rowCount, alItemDetail.Count);
                Application.DoEvents();

            }

            this.neuSpread1.ActiveSheetIndex = 1;

            #endregion

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在显示汇总，请稍后...");
            Application.DoEvents();

            #region 显示汇总

            this.neuSpread1.Sheets[1].Cells[alItemDetail.Count, 0].Value = "汇总：";
            this.neuSpread1.Sheets[1].Cells[alItemDetail.Count, 11].Formula = "sum(L1:L" + alItemDetail.Count.ToString() + ")";
            this.neuSpread1.Sheets[1].Cells[alItemDetail.Count, 13].Formula = "sum(N1:N" + alItemDetail.Count.ToString() + ")";

            #endregion

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
        }

        private void neuButton1_Click(object sender, EventArgs e)
        {
            this.ShowFeeDetailsToFP();
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            if (this.patientInfo == null)
            {
                MessageBox.Show("请输入患者住院号回车！");
                return;
            }
            if (this.alItemDetail == null || this.alItemDetail.Count == 0)
            {
                MessageBox.Show("患者没有需要上传的明细！");
                return;
            }
            string errTxt = "";
            int result = 0;

            Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在上传明细，请稍后...");
            Application.DoEvents();

            result = Functions.ExportInpatientFeedetail(FILE_PATH, this.patientInfo.SIMainInfo.RegNo, this.patientInfo, this.alItemDetail, ref errTxt);

            Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();

            if (result != 1)
            {
                MessageBox.Show("上传明细失败：" + errTxt);
                return;
            }
            MessageBox.Show("上传成功！\r\n下一步请用省医保程序做结算，再到HIS结算界面做出院结算！");
        }

        private void btnGetResult_Click(object sender, EventArgs e)
        {
            
        }
    }
}