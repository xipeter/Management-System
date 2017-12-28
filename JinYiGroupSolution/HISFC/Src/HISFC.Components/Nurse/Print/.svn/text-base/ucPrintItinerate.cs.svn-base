using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace Neusoft.HISFC.Components.Nurse.Print
{
    /// <summary>
    /// {637EDB0D-3F39-4fde-8686-F3CD87B64581} 打印改为接口方式
    /// </summary>
    public partial class ucPrintItinerate : UserControl, Neusoft.HISFC.BizProcess.Interface.Nurse.IInjectItineratePrint
    {
        #region 变量
        private ArrayList alPrint = new ArrayList();
        private Neusoft.HISFC.BizLogic.Nurse.Inject injectMgr = new Neusoft.HISFC.BizLogic.Nurse.Inject();
        private int iSet = 8;
        #endregion

        /// <summary>
        /// 
        /// </summary>
        public ucPrintItinerate()
        {
            InitializeComponent();
        }

        private void ucPrintItinerate_Load(object sender, EventArgs e)
        {
            this.neuSpread1_Sheet1.GrayAreaBackColor = System.Drawing.Color.White;
        }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="al"></param>
        public void Init(ArrayList al)
        {
            try
            {
                ArrayList alPrint = new ArrayList();
                int icount = Neusoft.FrameWork.Function.NConvert.ToInt32(Math.Ceiling(Convert.ToDouble(al.Count) / iSet));

                for (int i = 1; i <= icount; i++)
                {
                    if (i != icount)
                    {
                        alPrint = al.GetRange(iSet * (i - 1), iSet);
                        this.Print(alPrint, i, icount);
                    }
                    else
                    {
                        int num = al.Count % iSet;
                        if (al.Count % iSet == 0)
                        {
                            num = iSet;
                        }
                        alPrint = al.GetRange(iSet * (i - 1), num);
                        this.Print(alPrint, i, icount);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("打印出错!" + e.Message);
                return;
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="al">打印数组</param>
        /// <param name="current">当前页面数</param>
        /// <param name="total">总页数</param>
        private void Print(ArrayList al, int current, int total)
        {
            if (this.neuSpread1_Sheet1.RowCount > 0)
            {
                this.neuSpread1_Sheet1.RemoveRows(0, this.neuSpread1_Sheet1.RowCount);
            }
            Neusoft.HISFC.Models.Nurse.Inject info = null;

            //接瓶次数
            int jpNum = 1;
            //赋值并打印
            for (int i = 0; i < al.Count; i++)
            {
                info = (Neusoft.HISFC.Models.Nurse.Inject)al[i];
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                if (info.Item.Order.Combo.ID.Length <= 2)
                {
                    this.neuSpread1_Sheet1.Cells[0, 0].Text =
                        info.Item.Order.Combo.ID;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[0, 0].Text =
                        info.Item.Order.Combo.ID.Substring(info.Item.Order.Combo.ID.Length - 2, 2);
                }
                //this.neuSpread1_Sheet1.Cells[0, 0].Text = info.Item.Order.Combo.ID;
                if (info.Item.Item.Name != null && info.Item.Item.Name != "")
                {
                    this.neuSpread1_Sheet1.Cells[0, 1].Text = info.Item.Item.Name;
                }
                else
                {
                    this.neuSpread1_Sheet1.Cells[0, 1].Text = info.Item.Name;
                }
                
                jpNum = Neusoft.FrameWork.Function.NConvert.ToInt32(info.Memo);
                if (jpNum == 0)
                {
                    jpNum = 1;
                }
                this.neuSpread1_Sheet1.Cells[0, 2].Text =
                    Math.Round(info.Item.Order.DoseOnce / jpNum, 3).ToString() + info.Item.Order.DoseUnit.ToString();
                this.neuSpread1_Sheet1.Cells[0, 3].Text = "";
                this.neuSpread1_Sheet1.Cells[0, 4].Text = "";
                this.neuSpread1_Sheet1.Cells[0, 5].Text = " ";
                this.neuSpread1_Sheet1.Cells[0, 6].Text = " ";
            }
            info = (Neusoft.HISFC.Models.Nurse.Inject)al[0];
            this.lbCard.Text = info.Patient.PID.CardNO;
            this.lbName.Text = info.Patient.Name;
            this.lbTime.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            this.lbAge.Text = this.injectMgr.GetAge(info.Patient.Birthday, System.DateTime.Now);
            if (info.Patient.Sex.ID.ToString() == "M")
            {
                this.lbSex.Text = "男";
            }
            else if (info.Patient.Sex.ID.ToString() == "F")
            {
                this.lbSex.Text = "女";
            }
            else
            {
                this.lbSex.Text = "";
            }

            this.lbPage.Text = "第" + current.ToString()
                + "页" + "/" + "共" + total.ToString() + "页";

            this.neuSpread1_Sheet1.Rows.Add(this.neuSpread1_Sheet1.RowCount, 1);
            this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.RowCount - 1, 1].Text = "拔针";
            for (int i = 0; i < this.neuSpread1_Sheet1.RowCount; i++)
            {
                this.neuSpread1_Sheet1.Columns[2].HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            }
            this.Print();

        }

        /// <summary>
        /// 
        /// </summary>
        private void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = null;
            if (p == null)
            {
                p = new Neusoft.FrameWork.WinForms.Classes.Print();
                //neusoft.Common.Class.Function.GetPageSize("Inject2", ref p);
            }
            //System.Windows.Forms.Control c = this;
            //c.Width = this.Width;
            //c.Height = this.Height;
            //p.ControlBorder = Neusoft.FrameWork.WinForms.Classes.enuControlBorder.None;
            p.PrintPage(12, 1, this.pnlPrint);
        }
    }
}
