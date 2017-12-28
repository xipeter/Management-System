using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.NFC.Object;
using Neusoft.HISFC.Object.Operation;

namespace UFC.Operation
{
    /// <summary>
    /// [功能描述: 手术安排，麻醉安排打印单]<br></br>
    /// [创 建 者: 王铁全]<br></br>
    /// [创建时间: 2007-01-05]<br></br>
    /// <修改记录
    ///		修改人=''
    ///		修改时间='yyyy-mm-dd'
    ///		修改目的=''
    ///		修改描述=''
    ///  />
    /// </summary>
    public partial class ucArrangePrint : UserControl, Neusoft.HISFC.Integrate.Operation.IArrangePrint
    {
        public ucArrangePrint()
        {
            InitializeComponent();
            this.neuSpread1_Sheet1.ColumnHeader.Rows[0].Height = 28;
            this.neuSpread1_Sheet1.ColumnHeader.Rows[0].BackColor = Color.White;

        }

#region 字段

        Neusoft.NFC.Interface.Classes.Print print = new Neusoft.NFC.Interface.Classes.Print();
        Neusoft.HISFC.Integrate.Operation.EnumArrangeType arrangeType = Neusoft.HISFC.Integrate.Operation.EnumArrangeType.Anaesthesia;
#endregion

#region 属性

        public string Title
        {
            set
            {
                this.neuLabel1.Text = value;
            }
        }
        public DateTime Date
        {
            set
            {
                this.neuLabel2.Text = string.Concat("截止", value.ToString("yyyy-MM-dd hh:mm:ss"));
            }
        }


    
#endregion

        #region IReportPrinter 成员

        /// <summary>
        /// 导出
        /// </summary>
        /// <returns></returns>
        public int Export()
        {
            return 0;
        }

        /// <summary>
        /// 打印
        /// </summary>
        /// <returns></returns>
        public int Print()
        {
            return 0;
        }

        /// <summary>
        /// 打印预览
        /// </summary>
        /// <returns></returns>
        public int PrintPreview()
        {
            return this.print.PrintPreview(10,0,this);
        }

        #endregion


        #region IArrangePrint 成员

        /// <summary>
        /// 添加申请单
        /// </summary>
        /// <param name="appliction"></param>
        public void AddAppliction(Neusoft.HISFC.Object.Operation.OperationAppllication appliction)
        {
            if (appliction == null)
                return;

            this.neuSpread1_Sheet1.RowCount += 1;
            int i = this.neuSpread1_Sheet1.RowCount - 1;
            this.neuSpread1_Sheet1.Rows[i].Height = 30;
            this.neuSpread1_Sheet1.Rows[i].VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Center;
            this.neuSpread1_Sheet1.Rows[i].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Center;

            this.neuSpread1_Sheet1.Cells[i, 0].Text = appliction.PatientInfo.PVisit.PatientLocation.Dept.Name;
            this.neuSpread1_Sheet1.Cells[i, 1].Text = appliction.PatientInfo.PVisit.PatientLocation.Bed.ID;
            this.neuSpread1_Sheet1.Cells[i, 2].Text = appliction.PatientInfo.Name;
            this.neuSpread1_Sheet1.Cells[i, 3].Text = appliction.PatientInfo.Sex.Name;
            this.neuSpread1_Sheet1.Cells[i, 4].Text = appliction.PatientInfo.Age;
            //术前诊断
            if (appliction.DiagnoseAl.Count > 0)
                this.neuSpread1_Sheet1.Cells[i, 5].Text = (appliction.DiagnoseAl[0] as NeuObject).Name;
            //手术名称
            this.neuSpread1_Sheet1.Cells[i, 6].Text = appliction.MainOperationName;

            if (this.arrangeType == Neusoft.HISFC.Integrate.Operation.EnumArrangeType.Operation)
            {
                this.neuSpread1_Sheet1.Cells[i, 7].Text = appliction.OperationDoctor.Name;
                this.neuSpread1_Sheet1.Cells[i, 8].Text = appliction.OpsTable.ID;
                //洗手护士
                string nurse = string.Empty;
                foreach (ArrangeRole role in appliction.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.WashingHandNurse.ToString())
                    {
                        nurse += role.Name + "\n";
                    }
                }
                this.neuSpread1_Sheet1.Cells[i, 9].Text = nurse;
                //巡回护士
                nurse = string.Empty;
                foreach (ArrangeRole role in appliction.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.ItinerantNurse.ToString())
                    {
                        nurse += role.Name + "\n";
                    }
                }
                this.neuSpread1_Sheet1.Cells[i, 10].Text = nurse;
            }
            else
            {                
                //麻醉类型
                this.neuSpread1_Sheet1.Cells[i, 11].Text = appliction.AnesType.Name;
                //主麻
                string nurse = string.Empty;
                foreach (ArrangeRole role in appliction.RoleAl)
                {
                    if (role.RoleType.ID.ToString() == EnumOperationRole.Anaesthetist.ToString())
                    {
                        nurse += role.Name + "\n";
                    }
                }
                this.neuSpread1_Sheet1.Cells[i, 12].Text = nurse;
                this.neuSpread1_Sheet1.Cells[i, 13].Text = appliction.OpsTable.Name;   

            }
        }

        /// <summary>
        /// 清空
        /// </summary>
        public void Reset()
        {
            this.neuSpread1_Sheet1.RowCount = 0;
        }

        /// <summary>
        /// 安排类型
        /// </summary>
        public Neusoft.HISFC.Integrate.Operation.EnumArrangeType ArrangeType
        {
            get
            {
                return this.arrangeType;
            }
            set
            {
                this.arrangeType = value;
                if (this.arrangeType == Neusoft.HISFC.Integrate.Operation.EnumArrangeType.Operation)
                {
                    this.neuSpread1_Sheet1.Columns[7].Visible = true;
                    this.neuSpread1_Sheet1.Columns[8].Visible = true;
                    this.neuSpread1_Sheet1.Columns[9].Visible = true;
                    this.neuSpread1_Sheet1.Columns[10].Visible = true;
                    this.neuSpread1_Sheet1.Columns[11].Visible = false;
                    this.neuSpread1_Sheet1.Columns[12].Visible = false;
                    this.neuSpread1_Sheet1.Columns[13].Visible = false;
                    
                }else
                {
                    this.neuSpread1_Sheet1.Columns[7].Visible = false;
                    this.neuSpread1_Sheet1.Columns[8].Visible = false;
                    this.neuSpread1_Sheet1.Columns[9].Visible = false;
                    this.neuSpread1_Sheet1.Columns[10].Visible = false;
                    this.neuSpread1_Sheet1.Columns[11].Visible = true;                    
                    this.neuSpread1_Sheet1.Columns[12].Visible = true;
                    this.neuSpread1_Sheet1.Columns[13].Visible = true;
                }
            }
        }

        #endregion
    }
}
