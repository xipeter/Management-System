using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace Neusoft.HISFC.Components.Common.Forms
{
    public partial class frmSearchPatient : Form
    {
        public frmSearchPatient()
        {
            InitializeComponent();
        }

        #region 全局变量
        //病人基本信息表
        private DataTable patientTable;
        private DataView patientView;
        // 配置文件路径 
        private string FilePath = Application.StartupPath + "\\profile\\SearchPatient.xml";
        //双击事件 是否关闭窗体
        //private neusoft.Common.Class.FormStyleInfo dcEvent;
        #endregion

        #region 自定义事件
        //定义托管事件
        public delegate void SaveHandel(Neusoft.HISFC.Models.RADT.PatientInfo pa);
        public event SaveHandel SaveInfo;
        #endregion

        #region 方法

        /// <summary>
        /// 查询符合条件的信息
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        private void SearchInfo()
        {
            try
            {
                Neusoft.HISFC.BizLogic.RADT.InPatient inPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
                string strWhere = this.ucCustomQuery1.GetWhereString();
                if (strWhere == "")
                {
                    MessageBox.Show("请输入查询条件！");
                    return;
                }
                else
                {
                    strWhere = " where " + strWhere;
                }
                //等待窗口
                Neusoft.FrameWork.WinForms.Classes.Function.ShowWaitForm("正在查询数据，请稍候...");
                Application.DoEvents();
                ArrayList list = inPatient.PatientInfoGet(strWhere);
                if (list == null)
                {
                    MessageBox.Show("查询数据失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
                    return;
                }
                //插入数据
                InsertInfo(list);
                //设置fpSpread1 的属性
                if (System.IO.File.Exists(FilePath))
                {
                    Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, FilePath);
                }
                Neusoft.FrameWork.WinForms.Classes.Function.HideWaitForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 实例化 Table 查询数据 并填充数据
        /// zhangjunyi@neusoft.com 2005.6.29 
        /// </summary>
        private void LoadAndAddDateToTable()
        {
            patientTable = new DataTable("病人基本信息表");
            //如果配置文件存在,通过配置文件生成DataTable dtICD列信息,并绑定fp
            if (File.Exists(FilePath))
            {
                //定义DataTable
                //neusoft.Common.Class.Function.CreatColumnByXML(FilePath, patientTable, ref patientView, this.neuSpread1_Sheet1);
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.CreatColumnByXML(FilePath, patientTable, ref patientView,this.neuSpread1_Sheet1);
                //设置主键为sequence_no列
                CreateKeys(patientTable);
            }
            else//如果配置文件不存在,代码生成配置文件
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                //{379BA228-C5EC-4d9e-9552-35482B575E8D} 席宗飞 modified on 20100928
                patientTable.Columns.AddRange(new DataColumn[]{new DataColumn("住院流水号", strType),
                                                                  new DataColumn("科室", strType),
																  new DataColumn("住院号", strType),
																  new DataColumn("姓名", strType),
																  new DataColumn("性别", strType),
																  new DataColumn("身份证号", strType),
																  new DataColumn("生日", dtType),
																  new DataColumn("工作单位", strType),
																  new DataColumn("工作电话", strType),
																  new DataColumn("单位邮编", strType),
																  new DataColumn("户口或家庭地址", strType),
																  new DataColumn("家庭电话", strType),
																  new DataColumn("户口或家庭邮编", strType),
																  new DataColumn("籍贯", strType),
																  new DataColumn("民族", strType),
																  new DataColumn("联系人", strType),
																  new DataColumn("联系人电话", strType),
																  new DataColumn("联系人地址", strType),
																  new DataColumn("联系人关系", strType),
																  new DataColumn("婚姻状况", strType),
																  new DataColumn("入院日期",dtType),
																  new DataColumn("血型", strType),
																  new DataColumn("住院次数", intType),
																  new DataColumn("出院日期", dtType),
																  new DataColumn("就诊卡号", strType),
																  new DataColumn("医疗证号", strType),
											                      new DataColumn("合同单位", strType)});

                //设置主键为sequence_no列
                CreateKeys(patientTable);
                patientView = new DataView(patientTable);
                this.neuSpread1_Sheet1.DataSource = patientView;
                //保存网格的宽度
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, FilePath);
                
            }

            //设置fpSpread1 的属性
            if (System.IO.File.Exists(FilePath))
            {
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.ReadColumnProperty(this.neuSpread1_Sheet1, FilePath);
            }
        }

        /// <summary>
        ///设置FarPoint 的属性
        ///zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        private void SetUp(string filePath)
        {
            Neusoft.HISFC.Components.Common.Controls.ucSetColumn uc = new Neusoft.HISFC.Components.Common.Controls.ucSetColumn();
            uc.FilePath = filePath;
            if (filePath == FilePath)
            {
                //uc.GoDisplay += new neusoft.Common.Controls.ucSetCol.DisplayNow(uc_GoDisplay);
            }
            Neusoft.FrameWork.WinForms.Classes.Function.PopShowControl(uc);
        }
        /// <summary>
        /// 刷新患者信息
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        private void uc_GoDisplay()
        {
            //			SearchInfo();
        }
        /// <summary>
        /// 向table中插入数据。
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        /// <param name="alReturn"> 要插入的数据</param>
        private void InsertInfo(ArrayList alReturn)
        {
            if (patientTable != null)
            {
                patientTable.Clear();
            }
            //循环插入信息
            foreach (Neusoft.HISFC.Models.RADT.PatientInfo obj in alReturn)
            {
                DataRow row = patientTable.NewRow();
                SetRow(obj, row);
                patientTable.Rows.Add(row);
                patientTable.AcceptChanges();
            }
        }
        /// <summary>
        /// 在Table 中添加加一行
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        /// <param name="PatientInfo"></param>
        /// <param name="row"></param>
        private void SetRow(Neusoft.HISFC.Models.RADT.PatientInfo PatientInfo, DataRow row)
        {
            row["住院流水号"] = PatientInfo.ID;
            row["住院号"] = PatientInfo.PID.PatientNO;
            row["姓名"] = PatientInfo.Name;
            if (PatientInfo.Sex.ID.ToString() == "M")
            {
                row["性别"] = "男";
            }
            else if (PatientInfo.Sex.ID.ToString() == "F")
            {
                row["性别"] = "女";
            }
            else
            {
                row["性别"] = "未知";
            }
            row["身份证号"] = PatientInfo.IDCard;
            row["生日"] = PatientInfo.Birthday;
            row["工作单位"] = PatientInfo.CompanyName;
            row["工作电话"] = PatientInfo.PhoneBusiness;
            row["单位邮编"] = PatientInfo.BusinessZip;
            row["户口或家庭地址"] = PatientInfo.AddressHome;
            row["家庭电话"] = PatientInfo.PhoneHome;
            row["户口或家庭邮编"] = PatientInfo.HomeZip;
            row["籍贯"] = PatientInfo.DIST;
            row["民族"] = PatientInfo.Nationality.ID;
            row["联系人"] = PatientInfo.Kin.Name;
            row["联系人电话"] = PatientInfo.Kin.Memo;
            row["联系人地址"] = PatientInfo.Kin.User01;
            row["联系人关系"] = PatientInfo.Kin.Relation.Name;
            row["婚姻状况"] = PatientInfo.MaritalStatus.Name;
            row["入院日期"] = PatientInfo.PVisit.InTime;
            row["血型"] = PatientInfo.BloodType.Name;
            row["科室"] = PatientInfo.PVisit.PatientLocation.Dept.Name;
            row["住院次数"] = PatientInfo.InTimes;
            row["出院日期"] = PatientInfo.PVisit.OutTime;
            row["就诊卡号"] = PatientInfo.PID.CardNO;
            row["医疗证号"] = PatientInfo.SSN;
            row["合同单位"] = PatientInfo.Pact.Name;
        }

        /// <summary>
        /// 设置主键列
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        /// <param name="table"></param>
        private void CreateKeys(DataTable table)
        {
            DataColumn[] keys = new DataColumn[] { table.Columns["住院流水号"] };
            table.PrimaryKey = keys;
        }

        /// <summary>
        /// 自定义快捷键
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData.GetHashCode() == Keys.F.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //查询
                this.SearchInfo();
            }
            if (keyData.GetHashCode() == Keys.R.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //重置
            }
            if (keyData.GetHashCode() == Keys.S.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //设置
                SetUp(FilePath);
            }
            if (keyData.GetHashCode() == Keys.X.GetHashCode() + Keys.Alt.GetHashCode())
            {
                //关闭
                this.Close();
            }
            return base.ProcessDialogKey(keyData);
        }

        /// <summary>
        /// 当列宽度发生变化时,存储到配置文件
        /// zhangjunyi@neusoft.com 2005.6.29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_ColumnWidthChanged(object sender, FarPoint.Win.Spread.ColumnWidthChangedEventArgs e)
        {
            if (File.Exists(FilePath))
            {
                //neusoft.neuFC.Interface.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, FilePath);
                Neusoft.FrameWork.WinForms.Classes.CustomerFp.SaveColumnProperty(this.neuSpread1_Sheet1, FilePath);
            }
        }

        /// <summary>
        /// 控件的重置事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, System.EventArgs e)
        {
            this.ucCustomQuery1.btnReset_Click(sender, e);
        }

        private int GetColumnId(string str)
        {
            foreach (FarPoint.Win.Spread.Column col in neuSpread1_Sheet1.Columns)
            {
                if (col.Label == str)
                {
                    return col.Index;
                }
            }
            return 0;
        }
        #endregion

        private void neuSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            if (neuSpread1_Sheet1.Rows.Count < 1)
            {
                //没有数据 返回 
                return;
            }

            Neusoft.HISFC.Models.RADT.PatientInfo patient = new Neusoft.HISFC.Models.RADT.PatientInfo();
            //取出住院流水号 
            patient.ID = neuSpread1_Sheet1.Cells[neuSpread1_Sheet1.ActiveRowIndex, GetColumnId("住院流水号")].Text;
            Neusoft.HISFC.BizLogic.RADT.InPatient inPatient = new Neusoft.HISFC.BizLogic.RADT.InPatient();
            patient = inPatient.QueryPatientInfoByInpatientNO(patient.ID);
            //触发事件
            try
            {
                SaveInfo(patient);
            }
            catch (Exception ex)
            {
                string Err = ex.Message;
            }
            this.Close();
            //if (dcEvent == neusoft.Common.Class.FormStyleInfo.DCAutoClose)
            //{
            //    this.Close();
            //}
        }

        private void frmSearchPatient_Load(object sender, EventArgs e)
        {
            //构造Table的结构
            LoadAndAddDateToTable();
        }

        private void neuToolBar1_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (this.neuToolBar1.Buttons.IndexOf(e.Button))
            {
                case 0:
                    //查询
                    SearchInfo();
                    break;
                case 1:

                    //重置
                    break;
                case 2:
                    SetUp(FilePath);
                    //设置
                    break;
                case 3: //guan关闭
                    this.Close();
                    break;
            }
        }
    }
}