using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;
namespace Neusoft.HISFC.Components.HealthRecord.Search
{
    public partial class ucPatientList : UserControl
    {
        public delegate void ListShowdelegate(Neusoft.HISFC.Models.HealthRecord.Base obj);

        public event ListShowdelegate SelectItem;

        public ucPatientList()
        {
            InitializeComponent();
        }

        #region 全局变量
        /// <summary>
        /// 错误信息
        /// </summary>
        public string strErr = "";
        Neusoft.HISFC.BizLogic.HealthRecord.Base baseMgr = new Neusoft.HISFC.BizLogic.HealthRecord.Base();
        Neusoft.HISFC.Models.HealthRecord.Base baseObj = new Neusoft.HISFC.Models.HealthRecord.Base();
        Neusoft.HISFC.BizProcess.Integrate.RADT radtMgr = new Neusoft.HISFC.BizProcess.Integrate.RADT();
        #endregion 

        public Neusoft.HISFC.Models.HealthRecord.Base CaseBase
        {
            get
            {
                return baseObj;
            }
        }

        #region 枚举
        private enum Cols
        {
            outDept, //出院日期
            outTime,//入院日期
            strName,//姓名
            sexName,//性别
            inpatientNO,//住院流水号
            caseNo,//病案号
            patientNO,//住院号
            times,//第几次
            //Memo,
            //集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
            birthday,
            address
        }
        #endregion 

        #region 根据住院号查询 ,返回查询到的数组个数
        /// <summary>
        /// 根据住院号查询
        /// </summary>
        /// <param name="PatientNO">卡号</param>
        /// <param name="CardNOType">1,病案号,2 住院号</param>
        /// <returns></returns>
        public ArrayList Init(string PatientNO ,string CardNOType)
        {
            try
            {
                this.fpSpread1_Sheet1.RowCount = 0;
                ArrayList list = null;
                if (CardNOType == "1")
                { 
                    //list = baseMgr.QueryCaseBaseInfoByCaseNO(PatientNO);//根据住院号查询
                    list = baseMgr.QueryCasInfoByCasNo(PatientNO);
                }
                else if (CardNOType == "2") //根据住院号查询
                { 
                    //list = baseMgr.QueryPatientInfo(PatientNO);
                    list = baseMgr.QueryCasInfoByPatientNo(PatientNO);
                    //由于相同患者住院号可能不同，所以再按照姓名检索一遍{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                    //if (list != null && list.Count > 0)
                    //{
                    //    list = baseMgr.QueryPatientInfoByName((list[0] as Neusoft.HISFC.Models.HealthRecord.Base).PatientInfo.Name);
                    //}
                }
                //按照姓名检索一遍{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                else if (CardNOType == "3")
                {
                    list = baseMgr.QueryCasInfoByName(PatientNO);
                }
                if (list == null)
                {
                    this.strErr = baseMgr.Err;
                    return null;
                }
                foreach (Neusoft.HISFC.Models.HealthRecord.Base obj in list)
                {
                    int row = this.fpSpread1_Sheet1.Rows.Count;
                    this.fpSpread1_Sheet1.Rows.Add(row, 1);
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.outDept].Text = obj.OutDept.Name;//出院科室
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.outTime].Text = obj.PatientInfo.PVisit.OutTime.ToString("yyyy-MM-dd");//出院时间
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.strName].Text = obj.PatientInfo.Name;//姓名
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.sexName].Text = obj.PatientInfo.Sex.Name;//性别
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.inpatientNO].Text = obj.PatientInfo.ID;//住院流水号
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.caseNo].Text = obj.CaseNO; //病案号
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.caseNo].Tag = obj; //病案号
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.patientNO].Text = obj.PatientInfo.PID.PatientNO;//住院号
                    this.fpSpread1_Sheet1.Cells[row,(int)Cols.times].Text = obj.PatientInfo.InTimes.ToString();//入院次数
                    if (obj.PatientInfo.User01 == "病案信息" || CardNOType =="1" )
                    {
                        this.fpSpread1_Sheet1.Rows[row].BackColor = System.Drawing.Color.LightGreen;
                    }
                    //已回收
                    if (obj.CaseStat == "5")
                    {
                        this.fpSpread1_Sheet1.Rows[row].BackColor = System.Drawing.Color.LightBlue;
                    }
                    if (obj.PatientInfo.PVisit.InState.ID.ToString() != "O")
                    {
                        this.fpSpread1_Sheet1.Rows[row].BackColor = System.Drawing.Color.LightGray;
                    }
                    //集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.birthday].Text = obj.PatientInfo.Birthday.ToString("yyyy-MM-dd");
                    this.fpSpread1_Sheet1.Cells[row, (int)Cols.address].Text = obj.PatientInfo.AddressHome;
                }
                return list;
            }
            catch (Exception ex)
            {
                strErr = ex.Message;
                return null;
            }
        }
        #endregion 

        #region 双击时选取项目
        private void fpSpread1_CellDoubleClick(object sender, FarPoint.Win.Spread.CellClickEventArgs e)
        {
            baseObj = GetCaseInfo();
            if (baseObj != null)
            {
                this.Visible = false;
                SelectItem(baseObj);
            }
        }
        #endregion 

        #region 获取当前选择的项
        public Neusoft.HISFC.Models.HealthRecord.Base GetCaseInfo()
        {
            int Row = this.fpSpread1_Sheet1.ActiveRowIndex;
            if (Row == -1)
            {
                return null;
            }
            //集中修改病案室需求{C80E9978-D3E3-4af7-92F3-D91ED5288419}
            if (this.fpSpread1_Sheet1.Rows[Row].BackColor == System.Drawing.Color.LightGray)
            {
                MessageBox.Show("该患者未出院");
                return null;
            }
            if (this.fpSpread1_Sheet1.Rows[Row].BackColor == System.Drawing.Color.LightGreen)
            {
                //if (MessageBox.Show("该患者已存在病案记录，是否进行修改？", "提示", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                //{
                //    return null;
                //}
            }

            baseObj = (Neusoft.HISFC.Models.HealthRecord.Base)this.fpSpread1_Sheet1.Cells[Row, (int)Cols.caseNo].Tag;
            return baseObj;
        }
        #endregion 
        #region  上移下移
        /// <summary>
        /// 下一行
        /// </summary>
        public void NextRow()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            int _Row = fpSpread1_Sheet1.ActiveRowIndex;
            if (_Row < this.fpSpread1_Sheet1.RowCount-1)
            {
                _Row = _Row + 1;
                fpSpread1_Sheet1.ActiveRowIndex = _Row;
                fpSpread1_Sheet1.AddSelection(_Row, 0, 1, 0);
            }
        }
        /// <summary>
        /// 前一行
        /// </summary>
        public void PriorRow()
        {
            if (this.fpSpread1_Sheet1.RowCount == 0)
            {
                return;
            }
            int _Row = fpSpread1_Sheet1.ActiveRowIndex;
            if (_Row > 0)
            {
                _Row = _Row - 1;
                fpSpread1_Sheet1.ActiveRowIndex = _Row;
                fpSpread1_Sheet1.AddSelection(_Row, 0, 1, 0);
            }
        }
        #endregion 

        private void ucPatientList_Load(object sender, EventArgs e)
        {
            this.fpSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
        }

    }
}
