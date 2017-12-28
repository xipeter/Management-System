using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.HISFC.Models.RADT;

namespace Neusoft.HISFC.Components.Operation
{
    /// <summary>
    /// [功能描述: 费用查询患者列表]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-08]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucQueryFeePatient : UserControl
    {
        public ucQueryFeePatient()
        {
            InitializeComponent();
        }

#region 字段
        private List<PatientInfo> patients = new List<PatientInfo>();
#endregion

#region 属性
        public PatientInfo this[int index]
        {
            get
            {
                if (index >= this.patients.Count)
                {
                    throw new ApplicationException("index超过索引最大值");
                }

                return this.patients[index];
            }
        }
#endregion

#region 方法
        /// <summary>
        /// 添加患者
        /// </summary>
        /// <param name="patientInfo">患者信息</param>
        public void AddPatient(PatientInfo patientInfo)
        {
            fpSpread1_Sheet1.RowCount += 1;
            int row = fpSpread1_Sheet1.RowCount - 1;
            //住院号
            fpSpread1_Sheet1.SetValue(row, 0, patientInfo.PID.PatientNO, false);
            //姓名
            fpSpread1_Sheet1.SetValue(row, 1, patientInfo.Name, false);
            //性别
            fpSpread1_Sheet1.SetValue(row, 2, patientInfo.Sex.Name, false);
            //年龄            
            fpSpread1_Sheet1.SetValue(row, 3, patientInfo.Age, false);
            //住院科室
            fpSpread1_Sheet1.SetValue(row, 4, patientInfo.PVisit.PatientLocation.Dept.Name, false);
            //患者类别
            fpSpread1_Sheet1.SetValue(row, 5, patientInfo.Pact.PayKind.Name, false);
            //入院时间
            fpSpread1_Sheet1.SetValue(row, 6, patientInfo.PVisit.InTime, false);
            //状态
            fpSpread1_Sheet1.SetValue(row, 7, patientInfo.PVisit.InState.Name, false);
            //花费
            fpSpread1_Sheet1.SetValue(row, 8, patientInfo.FT.TotCost, false);
            //余额
            fpSpread1_Sheet1.SetValue(row, 9, patientInfo.FT.LeftCost, false);
            #region 判断有没有在本科室发生过费用
            //if (this.PatientList != null) //在本科室发生过费用 
            //{
            //    bool boolTemp = false;
            //    foreach (neusoft.HISFC.Object.RADT.PatientInfo info in this.PatientList)
            //    {
            //        if (info.ID == patientInfo.ID)
            //        {
            //            fpSpread1_Sheet1.SetValue(row, 10, "已经收费");
            //            boolTemp = true;
            //            break;
            //        }
            //    }
            //    if (!boolTemp)
            //    {
            //        fpSpread1_Sheet1.SetValue(row, 10, "没有收费");
            //    }
            //}
            //else
            //{
            //    fpSpread1_Sheet1.SetValue(row, 10, "没有收费");
            //}
            #endregion
            // 
            fpSpread1_Sheet1.Rows[row].Tag = patientInfo;
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Reset()
        {
            this.patients.Clear();
            this.fpSpread1_Sheet1.RowCount = 0;
        }
#endregion
    }
}
