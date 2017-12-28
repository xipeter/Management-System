using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;

namespace Neusoft.WinForms.Report.DrugStore
{
    /// <summary>
    /// 门诊注射清单 
    /// 
    /// <功能说明>
    ///     1、门诊注射清单打印  根据肿瘤项目需求形成
    /// </功能说明>
    /// </summary>
    public partial class ucZLInjectList : Neusoft.FrameWork.WinForms.Controls.ucBaseControl
    {
        public ucZLInjectList()
        {
            InitializeComponent();

            this.Init();
        }

        private static Neusoft.FrameWork.Public.ObjectHelper usageHelper = new Neusoft.FrameWork.Public.ObjectHelper();

        private void Init()
        {
            Neusoft.HISFC.BizLogic.Manager.Constant consManager = new Neusoft.HISFC.BizLogic.Manager.Constant();
            System.Collections.ArrayList alList = consManager.GetList(Neusoft.HISFC.Models.Base.EnumConstant.USAGE);

            usageHelper = new Neusoft.FrameWork.Public.ObjectHelper(alList);
        }

        public void AddAllData(System.Collections.ArrayList al)
        {
            if (al.Count <= 0)
            {
                return;
            }

            #region 中成药、草药打印

            try
            {
                try
                {
                    ComboSort comboSort = new ComboSort();
                    al.Sort(comboSort);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("数组排序发生错误" + ex.Message);
                    return;
                }

                int iIndex = this.neuSpread1_Sheet1.Rows.Count;
                foreach (Neusoft.HISFC.Models.Pharmacy.ApplyOut info in al)
                {
                    this.neuSpread1_Sheet1.Rows.Add(iIndex, 1);
                    this.neuSpread1_Sheet1.Cells[iIndex, 0].Text = info.CombNO;     //组合号
                    this.neuSpread1_Sheet1.Cells[iIndex, 2].Text = string.Format("{0}－{1}[{2}]  {3}{4}/{5}",info.Item.Name,Function.DrugDosage.GetStaticDosage(info.Item.ID),info.Item.Specs,info.Operation.ApplyQty,info.Item.MinUnit,usageHelper.GetName(info.Usage.ID));              //药品用药信息                    

                    this.lbInfo.Text = string.Format("姓名：{0}        日期：{1}     病历号：{2}",info.User02,info.Operation.ApplyOper.OperTime.ToString("yyyy-MM-dd"),info.PatientNO);
                }

                int groupID = 0;
                string privCombo = "-1";
                for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
                {
                    if (privCombo != this.neuSpread1_Sheet1.Cells[i, 0].Text)
                    {
                        groupID++;
                        this.neuSpread1_Sheet1.Cells[i, 1].Text = groupID.ToString();
                        privCombo = this.neuSpread1_Sheet1.Cells[i, 0].Text;
                    }
                    else
                    {
                        this.neuSpread1_Sheet1.Cells[i, 1].Text = groupID.ToString();
                    }
                }

                iIndex = this.neuSpread1_Sheet1.Rows.Count;
                this.neuSpread1_Sheet1.Rows.Add(iIndex, 2);
                iIndex = this.neuSpread1_Sheet1.Rows.Count - 1;
                this.neuSpread1_Sheet1.Cells[iIndex, 0].ColumnSpan = 7;
                this.neuSpread1_Sheet1.Cells[iIndex, 0].Text = "发药：              核对：                 护士核对：";
                this.neuSpread1_Sheet1.Rows[iIndex].Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(134)));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            #endregion
        }

        public void Preview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void Print()
        {
            Neusoft.FrameWork.WinForms.Classes.Print p = new Neusoft.FrameWork.WinForms.Classes.Print();
            p.IsResetPage = true;
            System.Drawing.Printing.PaperSize pageSize = this.getPaperSizeForInput();
            p.SetPageSize(pageSize);
            p.PrintPage(15, 10, this);
            //p.PrintPreview(15, 10, this.neuPanel1);
        }

        public void Clear()
        {
            this.lbInfo.Text = "";

            this.neuSpread1_Sheet1.Rows.Count = 0;
        }

        /// <summary>
        /// 入库单的纸张高度设置
        /// 默认情况下是三行入库数据的高度
        /// </summary>
        private System.Drawing.Printing.PaperSize getPaperSizeForInput()
        {
            System.Drawing.Printing.PaperSize paperSize = new System.Drawing.Printing.PaperSize();
            paperSize.PaperName = "rkd" + System.DateTime.Now.ToString();
            try
            {
                int width = 820;
                //int width = this.Width;
                int curHeight = this.Height;
                int addHeight = (this.neuSpread1_Sheet1.RowCount - 1) * (int)this.neuSpread1_Sheet1.Rows[0].Height;

                paperSize.Width = width;
                paperSize.Height = (addHeight + curHeight);
            }
            catch (Exception ex)
            {
                MessageBox.Show("设置入库打印纸张出错>>" + ex.Message);
            }
            return paperSize;
        }

        protected class ComboSort : System.Collections.IComparer
        {
            public ComboSort() { }


            #region IComparer 成员

            public int Compare(object x, object y)
            {
                // TODO:  添加 FeeSort.Compare 实现
                Neusoft.HISFC.Models.Pharmacy.ApplyOut obj1 = x as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                Neusoft.HISFC.Models.Pharmacy.ApplyOut obj2 = y as Neusoft.HISFC.Models.Pharmacy.ApplyOut;
                if (obj1 == null || obj2 == null)
                    throw new Exception("数组内必须为Pharmacy.ApplyOut类型");
                int i1 = NConvert.ToInt32(obj1.CombNO);
                int i2 = NConvert.ToInt32(obj2.CombNO);
                return i1 - i2;
            }

            #endregion
        }
    }
}
