using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace UFC.HealthRecord
{
    public partial class ucFeeInfo : UserControl
    {
        public ucFeeInfo()
        {
            InitializeComponent();
        }

        #region  变量
        private DataTable dtfeeInfo = new DataTable("诊断");
        public ArrayList feeInfoList = null;
        //金额列是否锁定的标志位 
        private bool boolType = false;
        //保存病人信息
        private Neusoft.HISFC.Object.RADT.PatientInfo patientInfo = new Neusoft.HISFC.Object.RADT.PatientInfo();
        #endregion

        #region 金额列是否可修改
        /// <summary>
        /// 设定金额是否可修改 
        /// </summary>
        public bool BoolType
        {
            get
            {
                return boolType;
            }
            set
            {
                boolType = value;
            }
        }
        #endregion

        #region  函数
        /// <summary>
        /// 限定格的宽度很可见性 
        /// </summary>
        private void SetFpEnter()
        {
            this.fpSpread1_Sheet1.Columns[0].Visible = false; //统计编码
            this.fpSpread1_Sheet1.Columns[1].Width = 129;//费用名称
            this.fpSpread1_Sheet1.Columns[1].Locked = true;
            this.fpSpread1_Sheet1.Columns[2].Width = 80;//费用金额
            this.fpSpread1_Sheet1.Columns[2].Locked = !boolType;
        }
        /// <summary>
        /// 清空原有的数据
        /// </summary>
        /// <returns></returns>
        public int ClearInfo()
        {
            if (this.dtfeeInfo != null)
            {
                this.dtfeeInfo.Clear();
                SetFpEnter();
            }
            else
            {
                MessageBox.Show("费用表为null");
            }
            return 1;
        }
        /// <summary>
        /// 校验数据的合法性。
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public int ValueState(ArrayList list)
        {
            if (list == null)
            {
                return -2;
            }
            foreach (Neusoft.HISFC.Object.RADT.Patient obj in list)
            {
                if (obj.ID == null || obj.ID == "")
                {
                    MessageBox.Show("费用信息 住院流水号不能为空");
                    return -1;
                }
                if (obj.ID.Length > 14)
                {
                    MessageBox.Show("费用信息 住院流水号过长");
                    return -1;
                }
                if (obj.DIST == null || obj.DIST == "")
                {
                    MessageBox.Show("费用信息 统计代码不能为空");
                    return -1;
                }
                if (obj.DIST.Length > 3)
                {
                    MessageBox.Show("费用信息 统计代码过长");
                    return -1;
                }
                if (obj.AreaCode == null || obj.AreaCode == "")
                {
                    MessageBox.Show("费用信息 统计名称不能为空");
                    return -1;
                }
                if (obj.AreaCode.Length > 16)
                {
                    MessageBox.Show("费用信息 统计名称过长");
                    return -1;
                }
                if (Neusoft.NFC.Function.NConvert.ToDecimal(obj.IDCard) > (decimal)99999999.99)
                {
                    MessageBox.Show("费用信息 金额过大");
                    return -1;
                }
            }
            return 1;
        }
        /// <summary>
        /// 获取费用信息
        /// </summary>
        /// <returns></returns>
        public ArrayList GetFeeInfoList()
        {
            feeInfoList = null;
            if (dtfeeInfo != null)
            {
                dtfeeInfo.AcceptChanges();//
                feeInfoList = new ArrayList();
                Neusoft.HISFC.Object.RADT.Patient info = null;
                foreach (DataRow row in dtfeeInfo.Rows)
                {
                    info = new Neusoft.HISFC.Object.RADT.Patient();
                    info.ID = patientInfo.ID;
                    info.DIST = row["统计编码"].ToString();//统计大类编码
                    if (info.DIST == "" || info.DIST == null)
                    {
                        continue;
                    }
                    info.AreaCode = row["费用名称"].ToString(); //统计名称 
                    if (row["费用金额"] != DBNull.Value)
                    {
                        info.IDCard = row["费用金额"].ToString();//统计费用 
                    }
                    feeInfoList.Add(info);
                }
            }
            return feeInfoList;
        }
        /// <summary>
        /// 查询并显示数据
        /// </summary>
        /// <returns>出错返回 －1 正常 0 不允许有病案1  </returns>
        public int LoadInfo(Neusoft.HISFC.Object.RADT.PatientInfo patient)
        {
            if (this.dtfeeInfo != null)
            {
                this.dtfeeInfo.Clear();
                this.dtfeeInfo.AcceptChanges();
            }
            if (patient == null)
            {
                return -1;
            }
            patientInfo = patient;
            if (patientInfo.CaseState == "0")
            {
                //不允许有病案
                return 1;
            }
            Neusoft.HISFC.Management.HealthRecord.Base ba = new Neusoft.HISFC.Management.HealthRecord.Base();
            Neusoft.HISFC.Management.HealthRecord.Fee feeCaseMgr = new Neusoft.HISFC.Management.HealthRecord.Fee();
            //查询符合条件的数据
            if (patientInfo.CaseState == "1")
            {
                feeInfoList = feeCaseMgr.QueryFeeInfoState(patientInfo.ID);
            }
            else
            {
                feeInfoList = feeCaseMgr.QueryFeeInfoState(patientInfo.ID);
            }
            if (feeInfoList == null)
            {
                return -1;
            }
            //循环插入数据
            foreach (Neusoft.HISFC.Object.RADT.Patient info in feeInfoList)
            {
                DataRow row = dtfeeInfo.NewRow();
                SetRow(row, info);
                dtfeeInfo.Rows.Add(row);
            }
            decimal tempDec = 0;
            foreach (Neusoft.HISFC.Object.RADT.Patient info in feeInfoList)
            {
                tempDec = tempDec + Neusoft.NFC.Function.NConvert.ToDecimal(info.IDCard);
            }
            Neusoft.HISFC.Object.RADT.Patient obj = new Neusoft.HISFC.Object.RADT.Patient();
            obj.AreaCode = "合计：";
            obj.IDCard = tempDec.ToString();
            DataRow rows = dtfeeInfo.NewRow();
            SetRow(rows, obj);
            dtfeeInfo.Rows.Add(rows);

            //更改标志
            dtfeeInfo.AcceptChanges();
            SetFpEnter();
            return 0;
        }
        /// <summary>
        /// 将实体中的值赋值到row中
        /// </summary>
        /// <param name="row">传入的row</param>
        /// <param name="info">传入的实体</param>
        private void SetRow(DataRow row, Neusoft.HISFC.Object.RADT.Patient info)
        {
            row["统计编码"] = info.DIST;//统计大类编码
            row["费用名称"] = info.AreaCode; //统计名称 
            row["费用金额"] = Neusoft.NFC.Function.NConvert.ToDecimal(info.IDCard);//统计费用 
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        /// <returns></returns>
        public int InitInfo()
        {
            this.InitDateTable();
            fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
            SetFpEnter();
            return 0;
        }
        /// <summary>
        /// 初始化表
        /// </summary>
        private void InitDateTable()
        {
            try
            {
                Type strType = typeof(System.String);
                Type intType = typeof(System.Int32);
                Type dtType = typeof(System.DateTime);
                Type boolType = typeof(System.Boolean);
                Type DecimalType = typeof(System.Decimal);

                dtfeeInfo.Columns.AddRange(new DataColumn[]{
															new DataColumn("统计编码", strType),	//0
															new DataColumn("费用名称", strType),	 //1
															new DataColumn("费用金额", DecimalType)});//9
                //绑定数据源
                this.fpSpread1_Sheet1.DataSource = dtfeeInfo;
                //				//设置fpSpread1 的属性
                //				if(System.IO.File.Exists(filePath))
                //				{
                //					Neusoft.NFC.Interface.Classes.CustomerFp.ReadColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
                //				else
                //				{
                //					Neusoft.NFC.Interface.Classes.CustomerFp.SaveColumnProperty(this.fpEnter1_Sheet1,filePath);
                //				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// 离开CELL时发生,用于  计算合计金额 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void fpSpread1_Sheet1_CellChanged(object sender, FarPoint.Win.Spread.SheetViewEventArgs e)
        {
            if (fpSpread1_Sheet1.ActiveColumnIndex == 2)
            {
                decimal tempDecimal = 0;
                for (int i = 0; i < fpSpread1_Sheet1.Rows.Count - 1; i++)
                {
                    //累计金额
                    tempDecimal += Neusoft.NFC.Function.NConvert.ToDecimal(fpSpread1_Sheet1.Cells[i, 2].Text);
                }
                //更改合计金额
                fpSpread1_Sheet1.Cells[fpSpread1_Sheet1.Rows.Count - 1, 2].Text = tempDecimal.ToString();
            }
        }
        #endregion 
    }
}
