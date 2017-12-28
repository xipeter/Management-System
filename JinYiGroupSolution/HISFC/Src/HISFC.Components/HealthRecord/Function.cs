using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Xml;
using System.Collections;
using System.IO;
namespace Neusoft.HISFC.Components.HealthRecord
{
    class Function
    {
        #region 通过XML创建和保存DataTable列信息

        /// <summary>
        /// 根据保存的XML信息,生成列信息
        /// </summary>
        /// <param name="pathName">XML文件存储位置</param>
        /// <param name="table">要初始化的DataTable</param>
        /// <param name="dv">DataTable的DataView</param>
        /// <param name="sv">绑定DataView的FarPointSheet</param>
        public static void CreatColumnByXML(string pathName, DataTable table, ref DataView dv, FarPoint.Win.Spread.SheetView sv)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                StreamReader sr = new StreamReader(pathName, System.Text.Encoding.Default);
                string cleandown = sr.ReadToEnd();
                doc.LoadXml(cleandown);
                sr.Close();
            }
            catch
            {
                return;
            }

            XmlNodeList nodes = doc.SelectNodes("//Column");

            string tempString = "";

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes["type"].Value == "TextCellType")
                {
                    tempString = "System.String";
                }
                else if (node.Attributes["type"].Value == "CheckBoxCellType")
                {
                    tempString = "System.Boolean";
                }
                else if (node.Attributes["type"].Value == "NumberCellType")
                {
                    tempString = "System.Decimal";
                }
                else if (node.Attributes["type"].Value == "DateTimeCellType")
                {
                    tempString = "System.DateTime";
                }
                else
                {
                    tempString = "System.String";
                }

                table.Columns.Add(new DataColumn(node.Attributes["displayname"].Value, Type.GetType(tempString)));
            }

            dv = new DataView(table);

            sv.DataSource = dv;
        }

        #endregion

        /// <summary>
        /// 打印病案首页
        /// </summary>
        /// <param name="info"></param>
        /// <returns>0正常  ，-1 出错</returns>
        public static int PrintCaseFirstPage(Neusoft.HISFC.Models.RADT.PatientInfo info)
        {
            HealthRecord.ucCasePrint casePrint = new HealthRecord.ucCasePrint();
            casePrint.LoadInfo();
            Neusoft.HISFC.BizLogic.HealthRecord.Base baseDml = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
            Neusoft.HISFC.BizProcess.Integrate.RADT RadtInpatient = new Neusoft.HISFC.BizProcess.Integrate.RADT();
            Neusoft.HISFC.Models.HealthRecord.Base caseBase = new Neusoft.HISFC.Models.HealthRecord.Base();
            //判断是否有该患者
            if (info.ID == null || info.ID == "")
            {
                MessageBox.Show("住院流水号不能为空");
                return -1;
            }
            //获取住院号赋值给实体
            Neusoft.HISFC.Models.RADT.PatientInfo patientInfo = RadtInpatient.GetPatientInfoByPatientNO(info.ID);
            if (patientInfo == null)
            {
                MessageBox.Show("获取人员信息出错");
                return -1;
            }
            caseBase.PatientInfo = patientInfo;
            //casePrint.contro = caseBase;
            //获取默认打印机
            string errStr = "";
            ArrayList alSetting = Neusoft.FrameWork.WinForms.Classes.Function.GetDefaultValue("BAPrinter", out errStr);
            if (alSetting == null)
            {
                MessageBox.Show(errStr);
                return -1;
            }
            if (alSetting.Count == 0)
            {
                MessageBox.Show("请填写打印机名称配置文件");
                Neusoft.FrameWork.WinForms.Classes.Function.SaveDefaultValue("BAPrinter");
                return -1;
            }
            string printerSetting = alSetting[0] as string;
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();

            for (int i = 0; i < System.Drawing.Printing.PrinterSettings.InstalledPrinters.Count; i++)
            {
                if (System.Drawing.Printing.PrinterSettings.InstalledPrinters[i].IndexOf(printerSetting) != -1)
                    p.PrintDocument.PrinterSettings.PrinterName = System.Drawing.Printing.PrinterSettings.InstalledPrinters[i];
            }

            p.IsPrintInputBox = true;
            Common.Classes.Function.GetPageSize("case1", ref p);
            p.PrintPage(20, 80, casePrint);
            return 0;
        }
        /// <summary>
        /// 打印病案首页
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int PrintCaseFPByFrm(Neusoft.HISFC.Models.RADT.PatientInfo info, object frmTag)
        {

            //			System.Windows.Forms.Form frmPrint = new Form();
            //			frmPrint.Size = new System.Drawing.Size(825,1070);
            //			casePrint.Dock= System.Windows.Forms.DockStyle.Fill;
            //			frmPrint.AutoScale = false;
            //			frmPrint.Controls.Add(casePrint);
            //			frmPrint.ShowDialog();
            //try
            //{
            //    HealthRecord.frmPrintCasePage frm = new frmPrintCasePage();
            //    frm.Tag = frmTag;
            //    frm.Show();
            //    //frm.Visible=false;
            //    return frm.Print(info);
            //}
            //catch
            //{
            return 0;
            //}


        }
        /// <summary>
        /// 打印病案首页
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public int PrintCaseFPByFrm(Neusoft.HISFC.Models.RADT.PatientInfo info)
        {

            //			System.Windows.Forms.Form frmPrint = new Form();
            //			frmPrint.Size = new System.Drawing.Size(825,1070);
            //			casePrint.Dock= System.Windows.Forms.DockStyle.Fill;
            //			frmPrint.AutoScale = false;
            //			frmPrint.Controls.Add(casePrint);
            //			frmPrint.ShowDialog();
            //try
            //{
            //    Case.frmPrintCasePage frm = new frmPrintCasePage();
            //    frm.Show();
            //    //frm.Visible=false;
            //    return frm.Print(info);
            //}
            //catch
            //{
            return 0;
            //}


        }
    }
}
