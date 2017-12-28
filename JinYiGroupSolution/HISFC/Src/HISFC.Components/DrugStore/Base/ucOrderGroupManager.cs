using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Neusoft.FrameWork.Function;
using Neusoft.FrameWork.Management;

namespace Neusoft.HISFC.Components.DrugStore.Base
{
    /// <summary>
    /// [功能描述: 医嘱批次设置<br></br>
    /// [创 建 者: 梁俊泽]<br></br>
    /// [创建时间: 2007-08-20]<br></br>
    /// </summary>
    public partial class ucOrderGroupManager : Neusoft.FrameWork.WinForms.Controls.ucBaseControl, Neusoft.FrameWork.WinForms.Forms.IMaintenanceControlable
    {
        public ucOrderGroupManager()
        {
            InitializeComponent();
        }

        #region 域变量

        /// <summary>
        /// 药品常数管理类
        /// </summary>
        private Neusoft.HISFC.BizLogic.Pharmacy.Constant consManager = new Neusoft.HISFC.BizLogic.Pharmacy.Constant();

        /// <summary>
        /// 系统时间
        /// </summary>
        DateTime sysTime;

        #endregion

        #region 方法

        /// <summary>
        /// 将医嘱设置信息加入Fp
        /// </summary>
        /// <returns></returns>
        private int AddDataToFp(List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> orderGroupList)
        {
            this.neuSpread1_Sheet1.Rows.Count = 0;

            int iIndex = 0;
            foreach (Neusoft.HISFC.Models.Pharmacy.OrderGroup info in orderGroupList)
            {
                this.neuSpread1_Sheet1.Rows.Add(iIndex, 1);

                this.neuSpread1_Sheet1.Cells[iIndex, 0].Text = info.ID;
                this.neuSpread1_Sheet1.Cells[iIndex, 1].Text = info.BeginTime.ToString("HH:mm:ss");
                this.neuSpread1_Sheet1.Cells[iIndex, 2].Text = info.EndTime.ToString("HH:mm:ss");
                this.neuSpread1_Sheet1.Cells[iIndex, 3].Text = info.Oper.ID;
                this.neuSpread1_Sheet1.Cells[iIndex, 4].Text = info.Oper.OperTime.ToString("yyyy-MM-dd HH:mm:ss");

                this.neuSpread1_Sheet1.Rows[iIndex].Tag = info;

                iIndex++;
            }

            return 1;
        }

        /// <summary>
        /// 由Fp内获取医嘱批次设置信息
        /// </summary>
        /// <param name="iRowIndex">行索引</param>
        /// <returns></returns>
        private Neusoft.HISFC.Models.Pharmacy.OrderGroup GetDataFromFp(int iRowIndex)
        {
            Neusoft.HISFC.Models.Pharmacy.OrderGroup orderGroup = new Neusoft.HISFC.Models.Pharmacy.OrderGroup();

            orderGroup.ID = this.neuSpread1_Sheet1.Cells[iRowIndex, 0].Text;
            orderGroup.BeginTime = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[iRowIndex, 1].Text);
            orderGroup.EndTime = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[iRowIndex, 2].Text);

            return orderGroup;
        }

        /// <summary>
        /// 增加新医嘱批次设置信息
        /// </summary>
        /// <returns></returns>
        private int AddNewOrderGroup()
        {
            int iCount = this.neuSpread1_Sheet1.Rows.Count;

            if (iCount == 0)                //第一次增加
            {
                this.neuSpread1_Sheet1.Rows.Add(0, 1);
                this.neuSpread1_Sheet1.Cells[0, 1].Text = this.sysTime.Date.ToString();
                this.neuSpread1_Sheet1.Cells[0, 1].Text = this.sysTime.Date.AddSeconds(-1).ToString();

                return 1;
            }

            this.neuSpread1_Sheet1.Rows.Add(iCount, 1);

            return 1;
        }

        /// <summary>
        /// 删除医嘱批次设置信息
        /// </summary>
        /// <returns></returns>
        protected int DelOrderGroup()
        {
            DialogResult rs = MessageBox.Show(Language.Msg("确认删除医嘱批次设置信息？"), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rs == DialogResult.No)
            {
                return 1;
            }

            string groupCode = this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 0].Text;
            DateTime dtBegin = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 1].Text);
            DateTime dtEnd = NConvert.ToDateTime(this.neuSpread1_Sheet1.Cells[this.neuSpread1_Sheet1.ActiveRowIndex, 2].Text);
            int returnValue = this.consManager.DelOrderGroup(groupCode,dtBegin,dtEnd);

            if (returnValue == -1)
            {
                MessageBox.Show(Language.Msg("删除医嘱批次设置信息发生错误"));
                return -1;
            }
            this.neuSpread1_Sheet1.Rows.Remove(this.neuSpread1_Sheet1.ActiveRowIndex, 1);

            if (returnValue == 0)
            {
                MessageBox.Show("删除成功！");
                return 1;
            }

            MessageBox.Show("删除成功！\n已经成功从数据库中删除信息");

            


            return 1;
        }

        /// <summary>
        /// 加载医嘱批次设置信息
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int QueryOrderGroup()
        {
            List<Neusoft.HISFC.Models.Pharmacy.OrderGroup> orderGroupList = this.consManager.QueryOrderGroup();
            if (orderGroupList == null)
            {
                MessageBox.Show(Language.Msg("获取医嘱批次设置信息发生错误"));
                return -1;
            }

            return this.AddDataToFp(orderGroupList);
        }

        /// <summary>
        /// 有效性保存
        /// </summary>
        /// <returns></returns>
        protected bool Valid()
        {
            return true;
        }

        /// <summary>
        /// 医嘱批次设置信息保存
        /// </summary>
        /// <returns>成功返回1 失败返回-1</returns>
        protected int SaveOrderGroup()
        {
            Neusoft.FrameWork.Management.PublicTrans.BeginTransaction();

            //Neusoft.FrameWork.Management.Transaction t = new Transaction(Neusoft.FrameWork.Management.Connection.Instance);
            //t.BeginTransaction();

            this.consManager.SetTrans(Neusoft.FrameWork.Management.PublicTrans.Trans);

            if (this.consManager.DelOrderGroup() == -1)
            {
                Neusoft.FrameWork.Management.PublicTrans.RollBack();
                MessageBox.Show(Language.Msg("删除医嘱批次设置信息发生错误"));
                return -1;
            }

            for (int i = 0; i < this.neuSpread1_Sheet1.Rows.Count; i++)
            {
                Neusoft.HISFC.Models.Pharmacy.OrderGroup orderGroup = this.GetDataFromFp(i);

                orderGroup.Oper.ID = this.consManager.Operator.ID;

                if (this.consManager.InsertOrderGroup(orderGroup) == -1)
                {
                    Neusoft.FrameWork.Management.PublicTrans.RollBack();
                    MessageBox.Show(Language.Msg("保存医嘱批次设置信息发生错误"));
                    return -1;
                }
            }

            Neusoft.FrameWork.Management.PublicTrans.Commit();

            MessageBox.Show(Language.Msg("保存成功"));

            return 1;
        }

        #endregion

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.F8)
            {
                this.neuDateTimePicker1.Visible = true;

                string group = this.consManager.GetOrderGroup(this.neuDateTimePicker1.Value);
                if (group == null)
                {
                    MessageBox.Show("Error");
                }
                else
                {
                    MessageBox.Show(group);
                }
            }
            return base.ProcessDialogKey(keyData);
        }

        #region IMaintenanceControlable 成员

        public int Add()
        {
            return this.AddNewOrderGroup();
        }

        public int Copy()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Cut()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Delete()
        {
            return this.DelOrderGroup();
        }

        public int Export()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Import()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Init()
        {
            this.sysTime = consManager.GetDateTimeFromSysDateTime();

            Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType markDateCellType = new Neusoft.FrameWork.WinForms.Classes.MarkCellType.DateTimeCellType();

            markDateCellType.DateTimeFormat = FarPoint.Win.Spread.CellType.DateTimeFormat.TimeOnly;

            this.neuSpread1_Sheet1.Columns[1].CellType = markDateCellType;
            this.neuSpread1_Sheet1.Columns[2].CellType = markDateCellType;

            return 1;
        }

        private bool isDirty = false;

        public bool IsDirty
        {
            get
            {
                return false;
            }
            set
            {
                this.isDirty = value;
            }
        }

        public int Modify()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int NextRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Paste()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PreRow()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Print()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintConfig()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int PrintPreview()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int Query()
        {
            return this.QueryOrderGroup();
        }

        public Neusoft.FrameWork.WinForms.Forms.IMaintenanceForm QueryForm
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public int Save()
        {
            return this.SaveOrderGroup();
        }

        #endregion
    }
}
